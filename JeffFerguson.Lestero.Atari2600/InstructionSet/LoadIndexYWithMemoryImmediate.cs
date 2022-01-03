namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class LoadIndexYWithMemoryImmediate : InstructionWithByteOperand
    {
        internal LoadIndexYWithMemoryImmediate(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Immediate, "LDY", 0xA0, 2, 2)
        {
        }
    }
}
