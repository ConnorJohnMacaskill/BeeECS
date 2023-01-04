using Asteroids.Assets;
using Asteroids.Behaviour;
using Asteroids.Utility;
using BeehaviorTree;
using BeehaviorTree.Nodes;
using BeehaviorTree.Nodes.Composite;
using BeehaviorTree.Nodes.Decorator;
using Logging.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResBee.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Factories
{
    public static class ValueFactory
    {
        public static void GetValue<T>(string raw, out dynamic value)
        {
            value = default(T);

            switch (value)
            {
                case Vector2 x:
                    value = GetVector2(raw, true);
                    break;
                case int x:
                    value = GetInt(raw, false);
                    break;
            }
        }

        public static int GetInt(string rawValue, bool required)
        {
            int retVal = -1;

            try
            {
                rawValue = rawValue.Trim();
                string[] parts = rawValue.Split(',');

                if (parts.Length == 1)
                {
                    retVal = int.Parse(parts[0].Trim());
                }
                else if (parts.Length == 2)
                {
                    int min = int.Parse(parts[0].Trim());
                    int max = int.Parse(parts[1].Trim());

                    retVal = RandomGenerator.GetRandomInt(min, max);
                }
                else
                {
                    HandleMalformedValue<int>(rawValue, required);
                }
            }
            catch(Exception ex)
            {
                HandleMalformedValue<int>(rawValue, required, ex);
            }

            return retVal;
        }

        public static double GetDouble(string rawValue, bool required)
        {
            double retVal = 0f;

            try
            {
                rawValue = rawValue.Trim();
                string[] parts = rawValue.Split(',');

                if (parts.Length == 1)
                {
                    retVal = double.Parse(parts[0].Trim());
                }
                else if (parts.Length == 2)
                {
                    double min = double.Parse(parts[0].Trim());
                    double max = double.Parse(parts[1].Trim());

                    retVal = RandomGenerator.GetRandomDouble(min, max);
                }
                else
                {
                    HandleMalformedValue<double>(rawValue, required);
                }
            }
            catch (Exception ex)
            {
                HandleMalformedValue<double>(rawValue, required, ex);
            }

            return retVal;
        }

        public static bool GetBool(string rawValue, bool required)
        {
            bool retVal = false;

            try
            {
                rawValue = rawValue.Trim();

                retVal = bool.Parse(rawValue);
            }
            catch(Exception ex)
            {
                HandleMalformedValue<bool>(rawValue, required, ex);
            }

            return retVal;
        }

        public static float GetFloat(string rawValue, bool required)
        {
            float retVal = 0f;

            try
            {
                rawValue = rawValue.Trim();
                string[] parts = rawValue.Split(',');

                if (parts.Length == 1)
                {
                    retVal = float.Parse(parts[0].Trim());
                }
                else if (parts.Length == 2)
                {
                    float min = float.Parse(parts[0].Trim());
                    float max = float.Parse(parts[1].Trim());

                    retVal = RandomGenerator.GetRandomFloat(min, max);
                }
                else
                {
                    HandleMalformedValue<float>(rawValue, required);
                }
            }
            catch(Exception ex)
            {
                HandleMalformedValue<float>(rawValue, required, ex);
            }

            return retVal;
        }

        public static string[] GetStringArray(string rawValue, bool required)
        {
            string[] retVal = new string[0];

            try
            {
                rawValue = rawValue.Trim();

                List<string> rawValues = rawValue.Split(',').ToList();
                rawValues.ForEach(x => x.Trim());

                retVal = rawValues.ToArray();
            }
            catch(Exception ex)
            {
                HandleMalformedValue<string[]>(rawValue, required, ex);
            }

            return retVal;
        }

        public static Vector2 GetVector2(string rawValue, bool required)
        {
            Vector2 retVal = Vector2.Zero;

            try
            {
                rawValue = rawValue.Trim();
                string[] parts = rawValue.Split(',');

                if (parts.Length == 2)
                {
                    int x = int.Parse(parts[0].Trim());
                    int y = int.Parse(parts[1].Trim());

                    retVal = new Vector2(x, y);
                }
                else
                {
                    HandleMalformedValue<Vector2>(rawValue, required);
                }
            }
            catch (Exception ex)
            {
                HandleMalformedValue<Vector2[]>(rawValue, required, ex);
            }

            return retVal;
        }

        public static Texture2D GetTexture(string rawValue, bool required)
        {
#warning Finish this off.
            return AssetStore.Instance.GetAsset<TextureAsset>(rawValue).Texture;
        }

        public static BehaviorTree GetBehaviourTree(string rawTree, bool required)
        {
#warning Finish this off behaviour.

            RotateTowardsTargetNode node = new RotateTowardsTargetNode();
            CheckFacingTargetNode targetNode = new CheckFacingTargetNode(0.3f);
            ActionShootNode shootNode = new ActionShootNode();
            SequenceNode sequenceNode = new SequenceNode(new INode[] { node, targetNode, shootNode }, false);

            CheckHasTargetNode checkTargetNode = new CheckHasTargetNode();
            //InverterNode inverter = new InverterNode(checkTargetNode);
            RotateToDefaultNode rotateToDefaultNode = new RotateToDefaultNode();
            SelectorNode rotateToDefaultRoot = new SelectorNode(new INode[] { checkTargetNode, rotateToDefaultNode }, false);

            SelectorNode root = new SelectorNode(new INode[] { sequenceNode, rotateToDefaultRoot }, false);

            return new BehaviorTree(root);
        }

        public static Color GetColor(string rawValue, bool required)
        {
#warning And this.
            return Color.White;
        }

        private static void HandleMalformedValue<T>(string value, bool required, Exception ex = null)
        {
            string valueType = typeof(T).Name;
            string error = string.Format("{0} value '{1}' is malformed.", valueType, value);

            Logging.Logger.Log(LogType.Error, error);

            if (required)
            {
                throw new Exception(error, ex);
            }
        }
    }
}
