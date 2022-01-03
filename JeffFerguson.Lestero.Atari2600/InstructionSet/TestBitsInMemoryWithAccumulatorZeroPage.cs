namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class TestBitsInMemoryWithAccumulatorZeroPage : InstructionWithByteOperand
    {
        internal TestBitsInMemoryWithAccumulatorZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "BIT", 0x24, 2, 3)
        {
        }
    }
}
