namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class ShiftLeftOneBitZeroPageX : InstructionWithByteOperand
    {
        internal ShiftLeftOneBitZeroPageX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPageX, "ASL", 0x16, 2, 6)
        {
        }
    }
}
