namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class ShiftLeftOneBitZeroPage : InstructionWithByteOperand
    {
        internal ShiftLeftOneBitZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "ASL", 0x06, 2, 5)
        {
        }
    }
}
