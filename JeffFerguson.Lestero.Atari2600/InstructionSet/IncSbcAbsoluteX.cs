namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class IncSbcAbsoluteX : InstructionWithWordOperand
    {
        internal IncSbcAbsoluteX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteX, "ISC", 0xFF, 3, 7)
        {
        }
    }
}
