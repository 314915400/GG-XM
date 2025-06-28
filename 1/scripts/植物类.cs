using System.Collections.Generic;
using UnityEngine;

// 植物类
public class 植物类 : MonoBehaviour
{
    public List<节点类> nodes; // 路线上的节点
    public GameObject branchPrefab; // 枝条预制体
    public GameObject flowerPrefab; // 花朵预制体
    public float branchLength = 1.0f; // 枝条长度
    public float branchSpread = 0.5f; // 枝条扩散范围
    public float maxDistanceToNode = 0.5f; // 到节点的最大距离，超过此距离开花

    private List<GameObject> branches = new List<GameObject>(); // 当前的枝条
    private int currentNodeIndex = 0; // 当前节点索引

    void Start()
    {
        // 从初始节点生成第一个枝条
        GenerateBranch(nodes[currentNodeIndex].position);
    }

    void Update()
    {
        // 每帧检查是否需要生成新的枝条或开花
        Grow();
    }

    void GenerateBranch(Vector3 targetPosition)
    {
        // 生成枝条
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 branchPosition = transform.position + direction * branchLength;
        GameObject branch = Instantiate(branchPrefab, branchPosition, Quaternion.LookRotation(direction));
        branches.Add(branch);

        // 检查是否需要开花
        if (Vector3.Distance(branchPosition, targetPosition) > maxDistanceToNode)
        {
            // 超出距离，开花
            Instantiate(flowerPrefab, branchPosition, Quaternion.identity);
        }
        else
        {
            // 未超出距离，继续生长
            currentNodeIndex++;
            if (currentNodeIndex < nodes.Count)
            {
                GenerateBranch(nodes[currentNodeIndex].position);
            }
        }
    }

    void Grow()
    {
        // 遍历所有枝条，让它们生长
        foreach (var branch in branches)
        {
            Vector3 direction = (nodes[currentNodeIndex].position - branch.transform.position).normalized;
            branch.transform.position += direction * branchLength * Time.deltaTime;
        }
    }
}
