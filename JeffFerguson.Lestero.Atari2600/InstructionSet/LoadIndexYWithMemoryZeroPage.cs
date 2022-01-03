namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class LoadIndexYWithMemoryZeroPage : InstructionWithByteOperand
    {
        internal LoadIndexYWithMemoryZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "LDY", 0xA4, 2, 3)
        {
        }
    }
}
