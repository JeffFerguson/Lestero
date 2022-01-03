namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// A base class for instructions with byte operands.
    /// </summary>
    internal class InstructionWithWordOperand : Instruction
    {
        protected ushort Operand { get; private set; }

        internal InstructionWithWordOperand(VirtualMachine vm, ushort address, AddressingForm addressing, string assembler, byte opcode, byte bytes, byte cycles)
            : base(vm, address, addressing, assembler, opcode, bytes, cycles)
        {
            Operand = vm.ReadWord((ushort)(address + 1));
        }

        public override string ToString()
        {
            return $"{this.Assembler} 0x{Operand:X4}";
        }
    }
}
