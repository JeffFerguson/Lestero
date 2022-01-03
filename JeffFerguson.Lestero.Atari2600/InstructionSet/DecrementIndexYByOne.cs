namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class DecrementIndexYByOne : Instruction
    {
        internal DecrementIndexYByOne(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "DEY", 0x88, 1, 2)
        {
        }
    }
}
