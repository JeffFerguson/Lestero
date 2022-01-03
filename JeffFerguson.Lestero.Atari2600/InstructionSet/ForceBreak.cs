namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class ForceBreak : Instruction
    {
        internal ForceBreak(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "BRK", 0x00, 1, 7)
        {
        }
    }
}
