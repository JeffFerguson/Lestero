namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class OrMemoryWithAccumulatorImmediate : InstructionWithByteOperand
    {
        internal OrMemoryWithAccumulatorImmediate(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Immediate, "ORA", 0x09, 2, 2)
        {
        }
    }
}
