using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient {
	public class GenericEventArgs<T> : EventArgs {
		public T payload;

		public GenericEventArgs(T payload) {
			this.payload = payload;
		}
	}
}
