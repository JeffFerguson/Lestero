namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class JumpToNewLocationAbsolute : InstructionWithWordOperand
    {
        internal JumpToNewLocationAbsolute(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Absolute, "JMP", 0x4C, 3, 3)
        {
        }
    }
}
