﻿using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace ContractParameterTest {
    public class Contract1 : FunctionCode {
        public static void Main() {
            Storage.Put(Storage.CurrentContext, "Hello", "World");
        }
    }
}
