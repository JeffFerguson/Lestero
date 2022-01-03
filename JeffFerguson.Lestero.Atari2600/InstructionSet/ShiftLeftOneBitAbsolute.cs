namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class ShiftLeftOneBitAbsolute : InstructionWithWordOperand
    {
        internal ShiftLeftOneBitAbsolute(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Absolute, "ASL", 0x0E, 3, 6)
        {
        }
    }
}
