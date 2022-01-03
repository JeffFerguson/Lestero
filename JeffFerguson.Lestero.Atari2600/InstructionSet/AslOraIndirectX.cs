namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class AslOraIndirectX : InstructionWithByteOperand
    {
        internal AslOraIndirectX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.IndirectX, "SLO", 0x03, 2, 8)
        {
        }
    }
}
