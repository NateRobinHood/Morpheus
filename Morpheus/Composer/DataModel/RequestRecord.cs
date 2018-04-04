using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Entity Framework
using System.ComponentModel.DataAnnotations;

namespace Composer.DataModel
{
    public class RequestRecord : IComparable
    {
        public Guid Id { get; set; }
        public string RequestUrl { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        #region IComparable
        public int CompareTo(object obj)
        {
            if (obj is RequestRecord)
            {
                RequestRecord compareObj = obj as RequestRecord;
                if (BitConverter.IsLittleEndian)
                {
                    if (BitConverter.ToInt64(this.RowVersion.Reverse().ToArray(), 0) <
                    BitConverter.ToInt64(compareObj.RowVersion.Reverse().ToArray(), 0))
                    {
                        return -1;
                    }
                    else if (BitConverter.ToInt64(this.RowVersion.Reverse().ToArray(), 0) <
                    BitConverter.ToInt64(compareObj.RowVersion.Reverse().ToArray(), 0))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (BitConverter.ToInt64(this.RowVersion.ToArray(), 0) <
                    BitConverter.ToInt64(compareObj.RowVersion.ToArray(), 0))
                    {
                        return -1;
                    }
                    else if (BitConverter.ToInt64(this.RowVersion.ToArray(), 0) <
                    BitConverter.ToInt64(compareObj.RowVersion.ToArray(), 0))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Type RequestRecord does not support IComapre to type {0}", obj.GetType().ToString()));
            }
        }
        #endregion
    }
}
