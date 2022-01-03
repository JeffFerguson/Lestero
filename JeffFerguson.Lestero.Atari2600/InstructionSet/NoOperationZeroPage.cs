namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class NoOperationZeroPage : InstructionWithByteOperand
    {
        internal NoOperationZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "NOP", 0x04, 2, 3)
        {
        }
    }
}
