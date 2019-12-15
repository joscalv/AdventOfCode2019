using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day14
    {
        private List<Reaction> _input = ReadInput();

        public int Part1()
        {
            OreCalculator calc = new OreCalculator(_input);
            return calc.GetOreFor1Fuel();
        }

        public static List<Reaction> ReadInput()
        {
            var reactionsStr = File.ReadAllText(@"Inputs\inputDay14.txt");
            return ReadInput(reactionsStr);

        }

        public static List<Reaction> ReadInput(string reactionsStr)
        {
            var test = reactionsStr
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseLine)
                .ToList();

            var d = test.ToDictionary(r => r.Result.Name, r => r);

            return test;
        }



        public static Reaction ParseLine(string reactionStr)
        {
            var test = reactionStr.Split("=>");

            var result = ParseComponent(test[1]);
            var inputs = test[0].Split(',').Select(ParseComponent).ToList();

            return new Reaction(inputs, result);
        }

        public static Component ParseComponent(string component)
        {
            var resultStr = component.Trim().Split(' ');
            return new Component(resultStr[1], int.Parse(resultStr[0]));
        }
    }

    public class OreCalculator
    {
        private readonly Dictionary<string, Reaction> _reactions;

        public OreCalculator(IList<Reaction> reactions)
        {
            _reactions = reactions.ToDictionary(r => r.Result.Name, r => r);
        }


        public int GetOreFor1Fuel()
        {
            return (int)GetOreFor("FUEL", 1, new Dictionary<string, int>());
        }

        public int GetOreFor1Fuel2()
        {
            return GetOreFor("FUEL", 1, new Dictionary<string, int>());
        }

        public int GetOreFor(string element, int quantity, Dictionary<string, int> extra)
        {

            int totalOre = 0;

            if (_reactions.TryGetValue(element, out var reaction))
            {
                int timesToApplyReaction = (int)Math.Ceiling(((double)quantity / reaction.Result.Quantity));

                int producedQuantity = reaction.Result.Quantity * timesToApplyReaction;
                if (producedQuantity > quantity)
                {
                    if (!extra.ContainsKey(element))
                    {
                        extra.Add(element, producedQuantity - quantity);
                    }
                    else
                    {
                        extra[element] = extra[element] + (producedQuantity - quantity);
                    }
                }

                foreach (var input in reaction.Inputs)
                {
                    var quantityToProduce = input.Quantity * timesToApplyReaction;

                    if (extra.TryGetValue(input.Name, out var existing))
                    {
                        if (existing > quantityToProduce)
                        {
                            quantityToProduce = 0;
                            extra[input.Name] = existing - quantityToProduce;
                        }
                        else
                        {
                            quantityToProduce = quantityToProduce - existing;
                            extra[input.Name] = 0;
                        }
                    }

                    if (input.Name == "ORE")
                    {
                        totalOre = totalOre + input.Quantity * timesToApplyReaction;
                    }
                    else
                    {

                        totalOre = totalOre + GetOreFor(input.Name, quantityToProduce, extra);
                    }
                }
            }

            return totalOre;
        }


        public int CalculateOre2(Reaction input)
        {
            var dInputs = input.Inputs.ToDictionary(i => i.Name, i => i);

            while (dInputs.Keys.Any(key => key != "ORE"))
            {
                var inputs = dInputs.Keys.Where(key => key != "ORE").ToList();

                foreach (var element in inputs)
                {

                    if (_reactions.TryGetValue(element, out var reaction))
                    {
                        int timesToApplyReaction =
                            (int)Math.Ceiling(((double)dInputs[element].Quantity / reaction.Result.Quantity));

                        foreach (Component component in reaction.Inputs)
                        {
                            if (dInputs.ContainsKey(component.Name))
                            {
                                dInputs[component.Name] =
                                    new Component(component.Name,
                                        dInputs[component.Name].Quantity + component.Quantity * timesToApplyReaction);

                            }
                            else
                            {
                                dInputs.Add(component.Name,
                                    new Component(component.Name, component.Quantity * timesToApplyReaction));
                            }
                        }
                    }

                    dInputs.Remove(element);
                }
            }

            return dInputs["ORE"].Quantity;

        }
    }

    public class Reaction
    {
        public Reaction(List<Component> inputs, Component result)
        {
            Inputs = inputs;
            Result = result;
        }
        public Component Result { get; set; }
        public List<Component> Inputs { get; set; }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (int i = 0; i < Inputs.Count; i++)
            {
                str.Append(Inputs[i].ToString());
                str.Append(i < (Inputs.Count - 1) ? "," : "=>");
            }
            str.Append(Result.ToString());

            return str.ToString();
        }
    }

    public class Component
    {
        public Component(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Level { get; set; }
        public override string ToString()
        {
            return $"{Quantity} {Name}";
        }
    }
}
