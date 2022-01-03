namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class LoadAccumulatorWithMemoryAbsoluteX : InstructionWithWordOperand
    {
        internal LoadAccumulatorWithMemoryAbsoluteX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteX, "LDA", 0xBD, 3, 4)
        {
        }
    }
}
