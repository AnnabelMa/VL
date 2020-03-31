using System;
namespace VL1.Aids {

    public interface ILogBook {
        void WriteEntry(string message);

        void WriteEntry(Exception e);
    }

}


