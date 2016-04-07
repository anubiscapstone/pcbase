using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AnubisClient
{
    public static class DefaultsParser
    {
        //State Machine for Parsing Comm Defaults
        private const string CommDefaultsFile = "CommDefaults.xml";
        private enum CommDefaultParseStates
        {
            Root,
            CommDefaults,
            Type,
            EndType,
            Param,
            ParamText,
            EndParam,
            Done
        }
        private static CommDefaultParseStates CommDefaultParseState;
        private static bool ChangeCommDefaultParseState(XmlNodeType type, string name)
        {
            if (type == XmlNodeType.Whitespace)
                return true;
            switch(CommDefaultParseState)
            {
                case (CommDefaultParseStates.Root):
                    if (type == XmlNodeType.XmlDeclaration)
                        break;
                    else if (type == XmlNodeType.Element && name == "CommDefaults")
                        CommDefaultParseState = CommDefaultParseStates.CommDefaults;
                    else
                        return false;
                    break;
                case (CommDefaultParseStates.CommDefaults):
                    if (type == XmlNodeType.Element && name == "Type")
                        CommDefaultParseState = CommDefaultParseStates.Type;
                    else
                        return false;
                    break;
                case (CommDefaultParseStates.Type):
                    if (type == XmlNodeType.Element && name == "Param")
                        CommDefaultParseState = CommDefaultParseStates.Param;
                    else if (type == XmlNodeType.EndElement && name == "Type")
                        CommDefaultParseState = CommDefaultParseStates.EndType;
                    else
                        return false;
                    break;
                case (CommDefaultParseStates.EndType):
                    if (type == XmlNodeType.Element && name == "Type")
                        CommDefaultParseState = CommDefaultParseStates.Type;
                    else if (type == XmlNodeType.EndElement && name == "CommDefaults")
                        CommDefaultParseState = CommDefaultParseStates.Done;
                    else
                        return false;
                    break;
                case (CommDefaultParseStates.Param):
                    if (type == XmlNodeType.Text)
                        CommDefaultParseState = CommDefaultParseStates.ParamText;
                    else if (type == XmlNodeType.EndElement && name == "Param")
                        CommDefaultParseState = CommDefaultParseStates.EndParam;
                    else
                        return false;
                    break;
                case (CommDefaultParseStates.ParamText):
                    if (type == XmlNodeType.EndElement && name == "Param")
                        CommDefaultParseState = CommDefaultParseStates.EndParam;
                    else
                        return false;
                    break;
                case (CommDefaultParseStates.EndParam):
                    if (type == XmlNodeType.Element && name == "Param")
                        CommDefaultParseState = CommDefaultParseStates.Param;
                    else if (type == XmlNodeType.EndElement && name == "Type")
                        CommDefaultParseState = CommDefaultParseStates.EndType;
                    else
                        return false;
                    break;
            }
            return true;
        }

        //Get Comm Defaults from File
        public static List<string> ParseCommDefaults(Type comm)
        {
            CommDefaultParseState = CommDefaultParseStates.Root;
            XmlTextReader reader = null;
            List<string> retval = new List<string>();
            try
            {
                string type_name = comm.Name;
                reader = new XmlTextReader(CommDefaultsFile);

                bool right_type = false;

                while (reader.Read())
                {
                    //Unexpected Token in Parser
                    if (!ChangeCommDefaultParseState(reader.NodeType, reader.Name))
                    {
                        retval = null;
                        break;
                    }
                    //Done Parsing
                    if (CommDefaultParseState == CommDefaultParseStates.Done || (CommDefaultParseState == CommDefaultParseStates.EndType && right_type))
                        break;
                    //Look for the right Comm Type
                    if(CommDefaultParseState == CommDefaultParseStates.Type)
                    {
                        reader.MoveToNextAttribute();
                        if (reader.Name == "name" && reader.Value == type_name)
                            right_type = true;
                    }
                    //Add the defaults to the return list
                    if (CommDefaultParseState == CommDefaultParseStates.ParamText && right_type)
                        retval.Add(reader.Value);
                }
            }
            catch (Exception) { return null; }
            finally { if(reader != null) reader.Close(); }
            return retval;
        }
    }
}
