using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace ContractParameterTest {
    public class Contract1 : FunctionCode {
        /**
         * helper contract to test the parameter editor in neo-developer-gui. Output added to "event log" tab of gui
         * 
         * param operation (05) should be one of: Boolean|Integer|ByteArray|Signature|Hash160|Hash256|PublicKey|String
         * param args must contain a single argument of the type matching operation
         */
        public static void Main(string operation, params object[] args) {

            Runtime.Log("Operation: " + operation);

            if (operation == "Boolean") {
                bool boolArg = (bool)args[0];
                if (boolArg) {
                    Runtime.Log("Operation: Boolean Value: true");
                } else {
                    Runtime.Log("Operation: Boolean Value: false");
                }
                return;
            }

            if (operation == "Integer") {
                Runtime.Log("processing Integer: " + args[0]);
                BigInteger intArg = (BigInteger)args[0];
                Runtime.Notify("Operation: Integer Value: ..", intArg);
                return;
            }

            if (operation == "ByteArray" || operation == "Signature") {
                Runtime.Log("processing " + operation);
                Runtime.Notify(operation, BytesToHex((byte[])args[0]));
                return;
            }

            if (operation == "Hash160" || operation == "Hash256" || operation == "PublicKey") {
                Runtime.Notify(operation, (byte[])args[0]);
                return;
            }

            if (operation == "String") {
                Runtime.Log("Operation: String Value: " + args[0]);
                return;
            }

            Runtime.Log("Unhandled operation: " + operation);
        }

        private static string BytesToHex(byte[] bytes) {
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++) {
                hexString += bytes[i];
            }
            return hexString;
        }
    }
}
