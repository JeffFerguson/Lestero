namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class OrMemoryWithAccumulatorZeroPage : InstructionWithByteOperand
    {
        internal OrMemoryWithAccumulatorZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "ORA", 0x05, 2, 3)
        {
        }
    }
}
