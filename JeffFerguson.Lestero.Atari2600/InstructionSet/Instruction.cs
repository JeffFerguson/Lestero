using System;

namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// Base class for all instructions.
    /// </summary>
    /// <remarks>
    /// The 6502 instruction set is at https://masswerk.at/6502/6502_instruction_set.html
    /// </remarks>
    internal class Instruction
    {
        internal VirtualMachine Machine { get; private set; }
        internal ushort RomAddress { get; private set; }
        internal AddressingForm Addressing { get; private set; }
        internal string Assembler { get; private set; }
        internal byte Opcode { get; private set; }
        internal byte Bytes { get; private set; }
        internal byte Cycles { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vm">
        /// The machine against which this instruction will execute.
        /// </param>
        /// <param name="address">
        /// The ROM address of the instruction.
        /// </param>
        /// <param name="addressing">
        /// The form of addressing for this instruction.
        /// </param>
        /// <param name="assembler">
        /// The string representation of this instruction as used in assembly code.
        /// </param>
        /// <param name="opcode">
        /// The opcode value for the instruction.
        /// </param>
        /// <param name="bytes">
        /// The number of bytes used for the instruction and any of its operands.
        /// </param>
        /// <param name="cycles">
        /// The CPU cycles used to execute the instruction.
        /// </param>
        internal Instruction(VirtualMachine vm, ushort address, AddressingForm addressing, string assembler, byte opcode, byte bytes, byte cycles)
        {
            this.Machine = vm;
            this.RomAddress = address;
            this.Addressing = addressing;
            this.Assembler = assembler;
            this.Opcode = opcode;
            this.Bytes = bytes;
            this.Cycles = cycles;
        }

        internal static Instruction GetInstruction(VirtualMachine vm, ushort address)
        {
            var opcode = vm.ReadByte(address);
            switch(opcode)
            {
                case 0x00:
                    return new ForceBreak(vm, address);
                case 0x01:
                    return new OrMemoryWithAccumulatorIndirectX(vm, address);
                case 0x02:
                    return new FreezeCpu(vm, address);
                case 0x03:
                    return new AslOraIndirectX(vm, address);
                case 0x04:
                    return new NoOperationZeroPage(vm, address);
                case 0x05:
                    return new OrMemoryWithAccumulatorZeroPage(vm, address);
                case 0x06:
                    return new ShiftLeftOneBitZeroPage(vm, address);
                case 0x07:
                    return new AslOraZeroPage(vm, address);
                case 0x08:
                    return new PushProcessorStatusOnStack(vm, address);
                case 0x09:
                    return new OrMemoryWithAccumulatorImmediate(vm, address);
                case 0x0A:
                    return new ShiftLeftOneBitAccumulator(vm, address);
                case 0x0C:
                    return new NoOperationAbsolute(vm, address);
                case 0x0D:
                    return new OrMemoryWithAccumulatorAbsolute(vm, address);
                case 0x0E:
                    return new ShiftLeftOneBitAbsolute(vm, address);
                case 0x10:
                    return new BranchOnResultPlus(vm, address);
                case 0x11:
                    return new OrMemoryWithAccumulatorIndirectY(vm, address);
                case 0x12:
                    return new FreezeCpu(vm, address);
                case 0x14:
                    return new NoOperationZeroPageX(vm, address);
                case 0x16:
                    return new ShiftLeftOneBitZeroPageX(vm, address);
                case 0x19:
                    return new OrMemoryWithAccumulatorAbsoluteY(vm, address);
                case 0x1D:
                    return new OrMemoryWithAccumulatorAbsoluteX(vm, address);
                case 0x20:
                    return new JumpToNewLocationSavingReturnAddress(vm, address);
                case 0x24:
                    return new TestBitsInMemoryWithAccumulatorZeroPage(vm, address);
                case 0x29:
                    return new AndMemoryWithAccumulatorImmediate(vm, address);
                case 0x30:
                    return new BranchOnResultMinus(vm, address);
                case 0x3F:
                    return new RolAndAbsoluteX(vm, address);
                case 0x42:
                    return new FreezeCpu(vm, address);
                case 0x49:
                    return new ExclusiveOrMemoryWithAccumulatorImmediate(vm, address);
                case 0x4C:
                    return new JumpToNewLocationAbsolute(vm, address);
                case 0x60:
                    return new ReturnFromSubroutine(vm, address);
                case 0x66:
                    return new RotateOneBitRightZeroPage(vm, address);
                case 0x78:
                    return new SetInterruptDisableStatus(vm, address);
                case 0x7F:
                    return new RorAdcAbsoluteX(vm, address);
                case 0x81:
                    return new StoreAccumulatorInMemoryIndirectX(vm, address);
                case 0x85:
                    return new StoreAccumulatorInMemoryZeroPage(vm, address);
                case 0x88:
                    return new DecrementIndexYByOne(vm, address);
                case 0x8A:
                    return new TransferIndexXToAccumulator(vm, address);
                case 0x95:
                    return new StoreAccumulatorInMemoryZeroPageX(vm, address);
                case 0x98:
                    return new TransferIndexYToAccumulator(vm, address);
                case 0x9A:
                    return new TransferIndexXToStackRegister(vm, address);
                case 0xA0:
                    return new LoadIndexYWithMemoryImmediate(vm, address);
                case 0xA2:
                    return new LoadIndexXWithMemoryImmediate(vm, address);
                case 0xA4:
                    return new LoadIndexYWithMemoryZeroPage(vm, address);
                case 0xA5:
                    return new LoadAccumulatorWithMemoryZeroPage(vm, address);
                case 0xA9:
                    return new LoadAccumulatorWithMemoryImmediate(vm, address);
                case 0xB5:
                    return new LoadAccumulatorWithMemoryZeroPageX(vm, address);
                case 0xB9:
                    return new LoadAccumulatorWithMemoryAbsoluteY(vm, address);
                case 0xBD:
                    return new LoadAccumulatorWithMemoryAbsoluteX(vm, address);
                case 0xCA:
                    return new DecrementIndexXByOne(vm, address);
                case 0xD0:
                    return new BranchOnResultNotZero(vm, address);
                case 0xD8:
                    return new ClearDecimalMode(vm, address);
                case 0xE7:
                    return new IncSbcZeroPage(vm, address);
                case 0xE8:
                    return new IncrementIndexXByOne(vm, address);
                case 0xEF:
                    return new IncSbcAbsolute(vm, address);
                case 0xFD:
                    return new SubtractMemoryFromAccumulatorWithBorrowAbsoluteX(vm, address);
                case 0xFE:
                    return new IncrementMemoryByOneAbsoluteX(vm, address);
                case 0xFF:
                    return new IncSbcAbsoluteX(vm, address);
                default:
                    throw new NotSupportedException($"Opcode 0x{opcode:X2} is not supported.");
            }
        }

        /// <summary>
        /// Execute the instruction.
        /// </summary>
        internal virtual void Execute()
        {
            throw new NotSupportedException($"Execution of instruction {ToString()}, implemented by class {this.GetType().ToString()}, is not supported.");
        }

        public override string ToString()
        {
            return Assembler;
        }

        /// <summary>
        /// Manages the state of the virtual machine's Zero Flag based on the value of the given parameter.
        /// </summary>
        /// <param name="value">
        /// The value to be used to determine the setting of the Zero Flag.
        /// </param>
        protected void ManageZeroFlag(byte value)
        {
            if(value == 0x00)
            {
                this.Machine.ZeroFlag = true;
            }
            else
            {
                this.Machine.ZeroFlag = false;
            }
        }

        /// <summary>
        /// Manages the state of the virtual machine's Negative Flag based on the value of the given parameters.
        /// </summary>
        /// <param name="oldValue">
        /// The old value.
        /// </param>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        protected void ManageNegativeFlag(byte oldValue, byte newValue)
        {
            var oldValueHighBit = GetHighBit(oldValue);
            var newValueHighBit = GetHighBit(newValue);
            this.Machine.NegativeFlag = oldValueHighBit != newValueHighBit;
        }


        /// <summary>
        /// Gets the high bit of a given value.
        /// </summary>
        /// <param name="value">
        /// A value whose high bit should be returned.
        /// </param>
        /// <returns>
        /// The high bit of the given value.
        /// </returns>
        private bool GetHighBit(byte value)
        {
            if ((value & (1 << 7)) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get the two's compliment of the given value.
        /// </summary>
        /// <param name="value">
        /// The original value.
        /// </param>
        /// <returns>
        /// The Two's Compliment of the given value.
        /// </returns>
        protected short GetTwosCompliment(byte value)
        {
            var twosComplimentOfValue = ~value;
            var lowByteOfTwosCompliment = twosComplimentOfValue & 0xFF;
            var valueAsShort = (short)(lowByteOfTwosCompliment);
            if (GetHighBit(value) == true)
            {
                return (short)(valueAsShort * -1);
            }
            else
            {
                return valueAsShort;
            }
        }
    }
}
