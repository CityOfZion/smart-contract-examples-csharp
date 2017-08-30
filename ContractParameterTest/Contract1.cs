using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace ContractParameterTest {
    public class Contract1 : FunctionCode {

        //[Appcall("d4e86a20af4cd4508de71c57bb211db8b1688a28")]
        //public static extern int CalculatorContract(string operation, params object[] args);
        /**
         * helper contract to test the parameter editor in neo-developer-gui. Output added to "event log" tab of gui
         * contract available on testnet at: 
         * 
         * param operation (05) should be one of: Boolean|Integer|ByteArray|Signature|Hash160|Hash256|PublicKey|Array|Calculator
         * param args must contain a single argument of the type matching operation unless you have used Calculator in which case you must provide string(add|sub), int, int
         */
        public static object Main(string operation, params object[] args) {

            Runtime.Log("Operation: " + operation);

            if(operation == "Calculator")
            {
                Runtime.Log("Not supported yet");
                //CalculatorContract((string)args[0], (int)args[1], (int)args[2]);
                return true;
            }

            if (operation == "Boolean") {
                bool boolArg = (bool)args[0];
                Runtime.Notify("Operation: Boolean Value: ", boolArg);
                return args[0];
            }

            if (operation == "Integer") {
                Runtime.Log("processing Integer: " + args[0]);
                BigInteger intArg = (BigInteger)args[0];
                Runtime.Notify("Operation: Integer Value: ", intArg);
                return args[0];
            }

            if (operation == "ByteArray" || operation == "Signature") {
                Runtime.Log("processing " + operation);
                Runtime.Notify(operation, BytesToHex((byte[])args[0]));
                return args[0];
            }

            if (operation == "Hash160" || operation == "Hash256" || operation == "PublicKey") {
                Runtime.Notify(operation, (byte[])args[0]);
                return args[0];
            }

            if(operation == "Array")
            {
                object[] arrayObject = (object[])args[0];
                Runtime.Notify(operation, arrayObject.Length);
                return arrayObject.Length;
            }

            Runtime.Log("Unhandled operation: " + operation);
            return false;
        }

        private static byte[] IntToBytes(BigInteger value)
        {
            byte[] buffer = value.ToByteArray();
            return buffer;
        }

        private static BigInteger BytesToInt(byte[] array)
        {
            var buffer = new BigInteger(array);
            return buffer;
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
