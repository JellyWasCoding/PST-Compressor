using System;
using func;

namespace PST {
    class PST {
        public static void Main(string[] args) {
            if (args.Length > 0) {
                if (args[0] == "true") func.PackScoreData(true);
                else func.PackScoreData(true);
            } else {
                func.PackScoreData(false);
            }
        }
    }
}