namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class PushProcessorStatusOnStack : Instruction
    {
        internal PushProcessorStatusOnStack(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "PHP", 0x08, 1, 3)
        {
        }
    }
}
