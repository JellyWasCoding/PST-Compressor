using PST;

namespace Program {
    class Program {
        public static void Main(string[] args) {
            if (args.Length > 0) {
                if (args[0].ToLower() == "true" || args[0].ToLower() == "t")
                    PieceTables.Pack(true);
                else 
                    PieceTables.Pack(false);
            } else {
                PieceTables.Pack(false);
            }
        }
    }
}
