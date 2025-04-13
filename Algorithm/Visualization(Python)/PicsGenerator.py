import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import os

df = pd.read_csv("C:\\dev\\results.csv")

df["VertexCount"] = df["VertexCount"].astype(int)
df["EdgeDensity"] = df["EdgeDensity"].astype(float)
df["Time"] = df["Time"].astype(float)


def plot_heatmap(data, title, filename):
    pivot = data.pivot(index="VertexCount", columns="EdgeDensity", values="Time")
    plt.figure(figsize=(10, 6))
    sns.heatmap(pivot, cmap="YlGnBu", annot=True, fmt=".4f")
    plt.title(title)
    plt.xlabel("Edge Density")
    plt.ylabel("Vertex Count")
    plt.tight_layout()
    plt.savefig(filename)
    plt.show()

os.makedirs("plots_by_density", exist_ok=True)

plot_heatmap(
    df[df["Representation"] == "Matrix"],
    "HeatMap — Matrix",
    "heatmap_matrix.png")


plot_heatmap(
    df[df["Representation"] == "List"],
    "HeatMap — List",
    "heatmap_list.png")

for representation in df["Representation"].unique():
    rep_df = df[df["Representation"] == representation]
    for density in sorted(rep_df["EdgeDensity"].unique()):
        subset = rep_df[rep_df["EdgeDensity"] == density]

        plt.figure(figsize=(8, 5))
        sns.lineplot(data=subset, x="VertexCount", y="Time", marker="o", linewidth=2)
        plt.title(f"{representation}: Time vs Vertex Count (Density = {density:.1f})")
        plt.xlabel("Vertex Count")
        plt.ylabel("Time (ms)")
        plt.grid(True)
        plt.tight_layout()

        filename = f"plots_by_density/{representation}_density_{density:.1f}.png"
        plt.savefig(filename)
        plt.close()