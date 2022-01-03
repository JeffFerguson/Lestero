namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class OrMemoryWithAccumulatorAbsoluteX : InstructionWithWordOperand
    {
        internal OrMemoryWithAccumulatorAbsoluteX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteX, "ORA", 0x1D, 3, 4)
        {
        }
    }
}
