namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class IncSbcZeroPage : InstructionWithByteOperand
    {
        internal IncSbcZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "ISC", 0xE7, 2, 5)
        {
        }
    }
}
