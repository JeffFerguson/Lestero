namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class OrMemoryWithAccumulatorIndirectY : InstructionWithByteOperand
    {
        internal OrMemoryWithAccumulatorIndirectY(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.IndirectY, "ORA", 0x11, 2, 5)
        {
        }
    }
}
