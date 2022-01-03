namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class ReturnFromSubroutine : Instruction
    {
        internal ReturnFromSubroutine(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "RTS", 0x60, 1, 6)
        {
        }
    }
}
