using JeffFerguson.Lestero.Atari2600.InstructionSet;
using System;
using System.Collections.Generic;
using System.IO;

namespace JeffFerguson.Lestero.Atari2600
{
    /// <summary>
    /// The ROM component of a virtual machine.
    /// </summary>
    internal class Rom
    {
        private byte[] bytes;
        private Dictionary<ushort, Instruction> InstructionsDictionary;

        /// <summary>
        /// The start address of ROM within the 6502 processor.
        /// </summary>
        internal static readonly ushort RomStartAddress = 0xF000;

        /// <summary>
        /// The end address of ROM within the 6502 processor.
        /// </summary>
        internal static readonly ushort RomEndAddress = 0xFFFF;

        /// <summary>
        /// The size of the ROM in the 6502 processor.
        /// </summary>
        internal static readonly ushort RomSize = (ushort)(RomEndAddress - RomStartAddress + 1);

        /// <summary>
        /// The reset vector address. The word address stored at this location points to the start
        /// of the program code in ROM.
        /// </summary>
        internal static readonly ushort ResetVectorAddress = 0xFFFB;

        private VirtualMachine virtualMachine;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vm">
        /// The virtual machine containing the RAM.
        /// </param>
        internal Rom(VirtualMachine vm)
        {
            bytes = new byte[RomSize];
            InstructionsDictionary = new Dictionary<ushort, Instruction>();
            virtualMachine = vm;
        }

        /// <summary>
        /// Load a ROM from file contents.
        /// </summary>
        /// <param name="path">
        /// The path of the file whose contents should be loaded into ROM.
        /// </param>
        internal void Load(string path)
        {
            var info = new FileInfo(path);
            if(info.Length > bytes.Length)
            {
                throw new NotSupportedException($"ROMs larger than {RomSize} bytes are not supported.");
            }
            bytes = File.ReadAllBytes(path);
        }

        /// <summary>
        /// Read the instructions in ROM.
        /// </summary>
        private void LoadInstructions()
        {
            var addressOfNextInstruction = GetAddressOfFirstInstruction();
            var keepReadingInstructions = true;
            while (keepReadingInstructions)
            {
                var nextInstruction = Instruction.GetInstruction(virtualMachine, addressOfNextInstruction);
                InstructionsDictionary.Add(nextInstruction.RomAddress, nextInstruction);
                addressOfNextInstruction += nextInstruction.Bytes;
                if (addressOfNextInstruction == 0xFFFF)
                {
                    keepReadingInstructions = false;
                }
            }
        }

        /// <summary>
        /// Determines whether or not a given address is within ROM.
        /// </summary>
        /// <param name="address">
        /// An address.
        /// </param>
        /// <returns>
        /// True if the address is within ROM; false otherwise.
        /// </returns>
        internal bool IsRomAddress(ushort address)
        {
            return (address >= RomStartAddress) && (address <= RomEndAddress);
        }

        /// <summary>
        /// Returns the instruction at the given address.
        /// </summary>
        /// <param name="instructionAddress">
        /// The address at which the instruction should be read.
        /// </param>
        /// <returns>
        /// The instruction at the given address. I literally just said that.
        /// </returns>
        internal Instruction GetInstructionAtProgramCounter(ushort instructionAddress)
        {
            var instructionFound = InstructionsDictionary.TryGetValue(instructionAddress, out var instructionAtProgramCounter);
            if (instructionFound == true)
            {
                return instructionAtProgramCounter;
            }
            var nextInstruction = Instruction.GetInstruction(virtualMachine, instructionAddress);
            InstructionsDictionary.Add(nextInstruction.RomAddress, nextInstruction);
            return nextInstruction;
        }

        /// <summary>
        /// Get the address of the beginning of the ROM code.
        /// </summary>
        /// <remarks>
        /// This address seems to be stored in ROM in big-endian format, unlike the instruction
        /// operands, which are stored in little-endian format.
        /// </remarks>
        /// <returns>
        /// The address of the beginning of the ROM code.
        /// </returns>
        internal ushort GetAddressOfFirstInstruction()
        {
            var byteOffset = ResetVectorAddress - RomStartAddress;
            var byte1 = bytes[byteOffset];
            var byte2 = bytes[byteOffset + 1];
            var word = (ushort)((byte1 << 8) + byte2);
            return word;
        }

        /// <summary>
        /// Read the word at the given address.
        /// </summary>
        /// <param name="address">
        /// The address storing the word to be read.
        /// </param>
        /// <returns>
        /// The word value at the address.
        /// </returns>
        internal ushort ReadWord(ushort address)
        {
            var byteOffset = address - RomStartAddress;
            var byte1 = bytes[byteOffset + 1];
            var byte2 = bytes[byteOffset];
            var word = (ushort)((byte1 << 8) + byte2);
            return word;
        }

        /// <summary>
        /// Read the byte at the given address.
        /// </summary>
        /// <param name="address">
        /// The address storing the word to be read.
        /// </param>
        /// <returns>
        /// The byte value at the address.
        /// </returns>
        internal byte ReadByte(ushort address)
        {
            var byteOffset = address - RomStartAddress;
            return bytes[byteOffset];
        }
    }
}
