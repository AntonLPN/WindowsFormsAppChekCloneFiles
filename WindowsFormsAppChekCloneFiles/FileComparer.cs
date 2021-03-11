using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppChekCloneFiles
{
    class FileComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            return x.Name == y.Name && x.Length == y.Length && x.LastWriteTime == y.LastWriteTime;
        }

        public int GetHashCode(FileInfo obj)
        {
            return $"{obj.Name } {obj.Length} {obj.LastWriteTime}".GetHashCode();
        }
    }
}
