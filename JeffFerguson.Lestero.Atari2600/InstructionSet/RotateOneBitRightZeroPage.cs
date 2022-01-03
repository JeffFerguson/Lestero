namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class RotateOneBitRightZeroPage : InstructionWithByteOperand
    {
        internal RotateOneBitRightZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "ROR", 0x66, 2, 5)
        {
        }
    }
}
