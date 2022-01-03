namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class NoOperationZeroPageX : InstructionWithByteOperand
    {
        internal NoOperationZeroPageX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPageX, "NOP", 0x14, 2, 4)
        {
        }
    }
}
