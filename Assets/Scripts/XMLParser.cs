using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class XMLParser {

	public static StaticEntityProperties[] ParseBuildings (string content)
    {
        XmlReader reader = XmlReader.Create(new StringReader(content));
        List<StaticEntityProperties> entities = new List<StaticEntityProperties>();
        StaticEntityProperties current = null;

        while (reader.Read())
        {
            if (reader.IsStartElement("building"))
            {
                if(current != null)
                {
                    entities.Add(current);
                }
                current = new StaticEntityProperties();
            }
            if (current != null)
            {
                if (reader.IsStartElement("id"))
                {
                    current.Id = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("name"))
                {
                    current.Name = reader.ReadElementContentAsString();
                }
                if (reader.IsStartElement("resources"))
                {
                    int food = 0, wood = 0, gold = 0;
                    food = int.Parse(reader.GetAttribute("food"));
                    gold = int.Parse(reader.GetAttribute("gold"));
                    wood = int.Parse(reader.GetAttribute("wood"));
                    current.NecessaryResources = new ResourceSet(wood, food, gold);
                }
                if (reader.IsStartElement("description"))
                {
                    current.Description = reader.ReadElementContentAsString();
                }
                if (reader.IsStartElement("availableOn"))
                {
                    current.AvailableOn = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("level"))
                {
                    current.Level = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("hp"))
                {
                    current.hp = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("script"))
                {
                    current.scriptInfo = new StaticUnitScriptInfo(string.Empty, new string[reader.AttributeCount]);
                    for(int i =0;i < reader.AttributeCount; i++)
                    {
                        current.scriptInfo.arguments[i] = reader.GetAttribute("arg" + i);
                    }
                    current.scriptInfo.script = reader.ReadElementContentAsString();
                }
            }
        }
        if(current != null)
        {
            entities.Add(current);
        }

        return entities.ToArray();
    }

    public static MobileEntityProperties[] ParseCharacters(string content)
    {
        XmlReader reader = XmlReader.Create(new StringReader(content));
        List<MobileEntityProperties> entities = new List<MobileEntityProperties>();
        MobileEntityProperties current = null;

        while (reader.Read())
        {
            if (reader.IsStartElement("character"))
            {
                if (current != null)
                {
                    entities.Add(current);
                }
                current = new MobileEntityProperties();
            }
            if (current != null)
            {
                if (reader.IsStartElement("id"))
                {
                    current.Id = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("name"))
                {
                    current.Name = reader.ReadElementContentAsString();
                }
                if (reader.IsStartElement("resources"))
                {
                    int food = 0, wood = 0, gold = 0;
                    food = int.Parse(reader.GetAttribute("food"));
                    gold = int.Parse(reader.GetAttribute("gold"));
                    wood = int.Parse(reader.GetAttribute("wood"));
                    current.NecessaryResources = new ResourceSet(wood, food, gold);
                }
                if (reader.IsStartElement("description"))
                {
                    current.Description = reader.ReadElementContentAsString();
                }
                if (reader.IsStartElement("availableOn"))
                {
                    current.AvailableOn = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("level"))
                {
                    current.Level = reader.ReadElementContentAsInt();
                }
            }
        }
        if (current != null)
        {
            entities.Add(current);
        }

        return entities.ToArray();
    }

    public static PCivil[] ParseCivil(string content)
    {
        XmlReader reader = XmlReader.Create(new StringReader(content));
        List<PCivil> entities = new List<PCivil>();
        PCivil current = null;

        while (reader.Read())
        {
            if (reader.IsStartElement("civil"))
            {
                if (current != null)
                {
                    entities.Add(current);
                }
                current = new PCivil();
            }
            if (current != null)
            {
                if (reader.IsStartElement("id"))
                {
                    current.id = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("nome"))
                {
                    current.nome = reader.ReadElementContentAsString();
                    Debug.Log(current.nome);
                }
                if (reader.IsStartElement("sexo"))
                {
                    switch (reader.ReadElementContentAsString())
                    {
                        case "F":
                        case "f":
                            {
                                current.sexo = Sexo.Femea;
                                break;
                            }
                        case "M":
                        case "m":
                            {
                                current.sexo = Sexo.Macho;
                                break;
                            }
                    }
                }
                if (reader.IsStartElement("recursosNecessarios"))
                {
                    List<Recurso> recursos = new List<Recurso>();
                    
                    recursos.Add(new Recurso(TipoRecurso.Alimento, int.Parse(reader.GetAttribute("alimento"))));
                    recursos.Add(new Recurso(TipoRecurso.Madeira, int.Parse(reader.GetAttribute("madeira"))));
                    recursos.Add(new Recurso(TipoRecurso.Ouro, int.Parse(reader.GetAttribute("ouro"))));

                    current.recursosNecessarios = new RecursosNecessarios(recursos);
                }
                if (reader.IsStartElement("descricao"))
                {
                    current.descricao = reader.ReadElementContentAsString();
                }
                if (reader.IsStartElement("vitalidade"))
                {
                    current.vitalidade = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("nivel"))
                {
                    current.nivel = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("velocidade"))
                {
                    current.velocidade = reader.ReadElementContentAsFloat();
                }
                if (reader.IsStartElement("expectativaDeVida"))
                {
                    current.expectativaDeVida = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("recursosColetadosPorSegundo"))
                {
                    current.recursosColetadosPorSegundo = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("maxRecursosPorCarregamento"))
                {
                    current.maxRecursosPorCarregamento = reader.ReadElementContentAsInt();
                }
                if (reader.IsStartElement("tiposColetaveis"))
                {
                    current.tiposColetaveis = new TipoRecurso[reader.AttributeCount];
                    for (int i = 0; i < reader.AttributeCount; i++)
                    {
                        switch(reader.GetAttribute("arg" + i))
                        {
                            case "alimento":
                                {
                                    current.tiposColetaveis[i] = TipoRecurso.Alimento;
                                    break;
                                }
                            case "madeira":
                                {
                                    current.tiposColetaveis[i] = TipoRecurso.Madeira;
                                    break;
                                }
                            case "ouro":
                                {
                                    current.tiposColetaveis[i] = TipoRecurso.Ouro;
                                    break;
                                }
                            case "pedra":
                                {
                                    current.tiposColetaveis[i] = TipoRecurso.Pedra;
                                    break;
                                }
                        }
                        
                    }
                }
            }
        }
        if (current != null)
        {
            entities.Add(current);
        }

        return entities.ToArray();
    }

}
