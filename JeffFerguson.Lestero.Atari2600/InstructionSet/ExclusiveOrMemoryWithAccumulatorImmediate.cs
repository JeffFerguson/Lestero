namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class ExclusiveOrMemoryWithAccumulatorImmediate : InstructionWithByteOperand
    {
        internal ExclusiveOrMemoryWithAccumulatorImmediate(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Immediate, "EOR", 0x49, 2, 2)
        {
        }
    }
}
