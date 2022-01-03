namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// A base class for instructions with byte operands.
    /// </summary>
    internal class InstructionWithByteOperand : Instruction
    {
        internal byte Operand { get; private set; }

        internal InstructionWithByteOperand(VirtualMachine vm, ushort address, AddressingForm addressing, string assembler, byte opcode, byte bytes, byte cycles)
            : base(vm, address, addressing, assembler, opcode, bytes, cycles)
        {
            Operand = vm.ReadByte((ushort)(address + 1));
        }

        public override string ToString()
        {
            return $"{this.Assembler} 0x{Operand:X2}";
        }
    }
}
