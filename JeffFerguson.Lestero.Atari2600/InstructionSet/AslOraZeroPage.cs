namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class AslOraZeroPage : InstructionWithByteOperand
    {
        internal AslOraZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "SLO", 0x07, 2, 5)
        {
        }
    }
}
