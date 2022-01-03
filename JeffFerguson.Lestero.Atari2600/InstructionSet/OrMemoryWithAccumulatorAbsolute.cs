namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class OrMemoryWithAccumulatorAbsolute : InstructionWithWordOperand
    {
        internal OrMemoryWithAccumulatorAbsolute(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Absolute, "ORA", 0x0D, 3, 4)
        {
        }
    }
}
