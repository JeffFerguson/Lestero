namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class StoreAccumulatorInMemoryIndirectX : InstructionWithByteOperand
    {
        internal StoreAccumulatorInMemoryIndirectX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.IndirectX, "STA", 0x81, 2, 6)
        {
        }
    }
}
