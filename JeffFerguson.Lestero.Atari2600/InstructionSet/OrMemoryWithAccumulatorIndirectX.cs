namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class OrMemoryWithAccumulatorIndirectX : InstructionWithByteOperand
    {
        internal OrMemoryWithAccumulatorIndirectX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.IndirectX, "ORA", 0x01, 2, 6)
        {
        }
    }
}
