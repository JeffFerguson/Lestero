namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class NoOperationAbsolute : InstructionWithWordOperand
    {
        internal NoOperationAbsolute(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Absolute, "NOP", 0x0C, 3, 4)
        {
        }
    }
}
