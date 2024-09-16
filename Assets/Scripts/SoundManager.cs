using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Dicionário para armazenar os eventos sonoros (Efeitos, Músicas, Sons de Ambiente)
    private Dictionary<string, EventReference> soundEvents = new Dictionary<string, EventReference>();

    // Dicionário para armazenar as instâncias ativas dos sons
    private Dictionary<string, FMOD.Studio.EventInstance> activeSounds = new Dictionary<string, FMOD.Studio.EventInstance>();

    [Header("Sons de Exemplo")]
    [SerializeField] private EventReference somExemploEvent; // Som de exemplo (pode ser efeito ou música)
    [SerializeField] private EventReference somAmbienteEvent; // Som de ambiente para loop

    void Start()
    {
        // Adicionando sons ao dicionário no início do jogo
        soundEvents.Add("somExemplo", somExemploEvent);
        soundEvents.Add("somAmbiente", somAmbienteEvent);
        
        // Exemplo de como adicionar novos sons:
        // soundEvents.Add("nomeDoSom", referenciaDoEventoNoFMOD);
        // Isso permite que novos sons sejam facilmente escalados.
    }

    // Método para tocar sons pontuais (Efeitos ou UI)
    public void PlaySound(string soundType)
    {
        if (soundEvents.ContainsKey(soundType))
        {
            FMOD.Studio.EventInstance soundInstance = RuntimeManager.CreateInstance(soundEvents[soundType]);
            soundInstance.start();
            soundInstance.release(); 
        }
        else
        {
            Debug.LogWarning("Som não encontrado: " + soundType);
        }
    }

    // Método para tocar sons em loop (Músicas, Sons de Ambiente)
    public void PlayLoopingSound(string soundType)
    {
        if (soundEvents.ContainsKey(soundType))
        {
            // Verifica se o som já está tocando para evitar duplicação
            if (!activeSounds.ContainsKey(soundType))
            {
                FMOD.Studio.EventInstance soundInstance = RuntimeManager.CreateInstance(soundEvents[soundType]);
                soundInstance.start();
                activeSounds[soundType] = soundInstance; // Armazena a instância para controle futuro
            }
        }
        else
        {
            Debug.LogWarning("Som de loop não encontrado: " + soundType);
        }
    }

    // Método para parar um som específico
    public void StopSound(string soundType)
    {
        if (activeSounds.ContainsKey(soundType))
        {
            // Parar o som específico e liberar a instância
            activeSounds[soundType].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            activeSounds[soundType].release();
            activeSounds.Remove(soundType); // Remove do dicionário após parar
        }
        else
        {
            Debug.LogWarning("Nenhum som ativo encontrado para: " + soundType);
        }
    }

    // Método para parar todos os sons ativos (Músicas, Ambiente)
    public void StopAllLoopingSounds()
    {
        foreach (var soundInstance in activeSounds.Values)
        {
            soundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            soundInstance.release();
        }
        activeSounds.Clear();
    }

    // Exemplos de Escalabilidade:
    // 1. Para adicionar novos sons, basta usar a mesma estrutura:
    //    soundEvents.Add("nomeDoSom", referenciaDoEventoNoFMOD);
    //    Isso pode ser feito em qualquer ponto, como ao carregar uma nova cena ou ambiente.
    
    // 2. Para tocar um novo som, basta chamar:
    //    PlaySound("nomeDoSom");
    //    Para sons de loop, use:
    //    PlayLoopingSound("nomeDoSom");
    
    // 3. Para parar um som específico ou todos os sons:
    //    StopSound("nomeDoSom");
    //    StopAllLoopingSounds(); // Para parar todos os sons de ambiente ou músicas que estão em loop.
}
