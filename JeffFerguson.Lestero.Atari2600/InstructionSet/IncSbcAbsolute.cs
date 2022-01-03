namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class IncSbcAbsolute : InstructionWithWordOperand
    {
        internal IncSbcAbsolute(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Absolute, "ISC", 0xEF, 3, 6)
        {
        }
    }
}
