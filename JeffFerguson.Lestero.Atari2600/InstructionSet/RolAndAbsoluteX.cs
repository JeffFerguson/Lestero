namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class RolAndAbsoluteX : InstructionWithWordOperand
    {
        internal RolAndAbsoluteX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteX, "RLA", 0x3F, 3, 7)
        {
        }
    }
}
