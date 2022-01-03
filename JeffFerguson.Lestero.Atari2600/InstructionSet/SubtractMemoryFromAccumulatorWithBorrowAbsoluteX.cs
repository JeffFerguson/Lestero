namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class SubtractMemoryFromAccumulatorWithBorrowAbsoluteX : InstructionWithWordOperand
    {
        internal SubtractMemoryFromAccumulatorWithBorrowAbsoluteX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteX, "SBC", 0xFD, 3, 4)
        {
        }
    }
}
