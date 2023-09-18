﻿namespace SharpRISCV
{
    public static class Address
    {
        private static int currentAddress = 0;
        public static Dictionary<string, int> Labels = new Dictionary<string, int>();

        public static void Reset() => currentAddress = 0;

        public static int EntryPoint
        {
            get
            {
                return Labels.FirstOrDefault(x => x.Key.Equals("main")).Value;
            }
        }
        public static string EntryPointHax { get { return $"0x{EntryPoint.ToString("X8")}"; } }

        public static int GetAndIncreseAddress()
        {
            int oldAddress = currentAddress;
            currentAddress += 4;
            return oldAddress;
        }

        public static int GetAndIncreseAddress(int by)
        {
            int oldAddress = currentAddress;
            currentAddress += by;
            return oldAddress;
        }

        public static int CurrentAddress { get { return currentAddress; } }

        public static void SetAddress (int address) => currentAddress = address;
    }
}
