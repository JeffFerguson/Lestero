namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class LoadAccumulatorWithMemoryZeroPageX : InstructionWithByteOperand
    {
        internal LoadAccumulatorWithMemoryZeroPageX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPageX, "LDA", 0xB5, 2, 2)
        {
        }
    }
}
