namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class LoadAccumulatorWithMemoryAbsoluteY : InstructionWithWordOperand
    {
        internal LoadAccumulatorWithMemoryAbsoluteY(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteY, "LDA", 0xB9, 3, 4)
        {
        }
    }
}
