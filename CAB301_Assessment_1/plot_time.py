import json
import matplotlib.pyplot as plt
from datetime import datetime

timestamps = []
execution_times = []
memory_usages = []
file_path = r"C:/Users/joshu/Documents/GitHub/CAB301_Work/CAB301_Assessment_1/bin/Debug/net8.0"

with open(f"{file_path}/metrics.jsonl", "r") as f:
    for line in f:
        entry = json.loads(line)
        timestamps.append(datetime.fromisoformat(entry["timestamp"]))
        execution_times.append(entry["executionTimeSeconds"])
        memory_usages.append(entry["memoryUsageMB"])

fig, (ax1, ax2) = plt.subplots(2, 1, figsize=(6, 6))

# Execution Time Plot
ax1.plot(timestamps, execution_times, marker='o')
ax1.set_title("Execution Time Over Time")
ax1.set_xlabel("Timestamp")
ax1.set_ylabel("Execution Time (s)")
ax1.tick_params(axis='x', rotation=45, direction="out")
ax1.grid(True)

# Memory Usage Plot
ax2.plot(timestamps, memory_usages, marker='o', color='orange')
ax2.set_title("Memory Usage Over Time")
ax2.set_xlabel("Timestamp")
ax2.set_ylabel("Memory Usage (MB)")
ax2.tick_params(axis='x', rotation=45, direction="out")
ax2.grid(True)

plt.tight_layout()
plt.show()
