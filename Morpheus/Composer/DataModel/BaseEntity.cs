using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer.DataModel
{
    public class BaseEntity : IComparable
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }

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
