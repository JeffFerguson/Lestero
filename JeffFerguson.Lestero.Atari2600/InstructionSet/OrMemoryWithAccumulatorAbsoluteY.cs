namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class OrMemoryWithAccumulatorAbsoluteY : InstructionWithWordOperand
    {
        internal OrMemoryWithAccumulatorAbsoluteY(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteY, "ORA", 0x19, 3, 4)
        {
        }
    }
}
